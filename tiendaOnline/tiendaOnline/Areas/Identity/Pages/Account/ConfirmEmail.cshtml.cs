using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using tiendaOnline.Areas.Identity.Data;
using tiendaOnline.Data;
using tiendaOnline.Models;

namespace tiendaOnline.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<tiendaOnlineUser> _userManager;        
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;

        public ConfirmEmailModel(UserManager<tiendaOnlineUser> userManager, ApplicationDbContext context, IEmailSender emailSender)
        {
            _userManager = userManager;
            _context = context;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Imposible cargar usuario con el id: '{userId}'.");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Error configurando el correo para el usuario con id: '{userId}':");
            }

            //generador random de codigo
            var chars = Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", 8);
            var randomStr = new string(chars.SelectMany(str => str)
                                            .OrderBy(c => Guid.NewGuid())
                                            .Take(8).ToArray());
            //cuponcito wapeton
            var cupon = new Cupon();
            cupon.codigoCupon = randomStr;
            cupon.montoCupon = 5.00;
            cupon.estadoCupon = true;
            cupon.descripcionCupon = "Cupón de nuevo usuario";
            cupon.tiendaOnlineUserID = user.Id;
            _context.Add(cupon);
            //Agregando carrito al usuario
            var carrito = new Carrito(user.Id);
            _context.Add(carrito);
            await _context.SaveChangesAsync();       
            
            //Enviando cupon al correo
            await _emailSender.SendEmailAsync(user.Email, "Cupon de descuento! :D", $"Este es tu cupon con $5 de descuento, recuerda que solo tu puedes usar el cupon :D "
            + $"Codigo cupon:'{(cupon.codigoCupon)}'</font></a>.");


            return Page();

        }
    }
}
