using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using tiendaOnline.Areas.Identity.Data;
using tiendaOnline.Data;
using tiendaOnline.Models;

namespace tiendaOnline.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<tiendaOnlineUser> _signInManager;
        private readonly UserManager<tiendaOnlineUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context; 

        public RegisterModel(
            UserManager<tiendaOnlineUser> userManager,
            SignInManager<tiendaOnlineUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage ="El campo de Email es requerido.")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage ="El campo de Contraseña es requerido.")]
            [StringLength(100, ErrorMessage = "La {0} debe tener una longitud de al menos {2} y un maximo de {1} caracteres.", MinimumLength = 8)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new tiendaOnlineUser { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("El usuario creó una nueva cuenta.");
                        
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirma tu correo electrónico",

                        $"<font face=',Times New Roman, verdana' size=6 color='FF3300'> <b>Enhorabuena, ¡ya estás en iBuy! </b><br/></font> <font face=',Times New Roman, verdana' size=4>¡Ya eres parte de la familia iBuy! Por seguridad, confirma tu dirección email.<br/>Confirmando tu dirección de email tu cuenta estará más segura. Podrás seguir tus pedidos más fácilmente, <br/>recibir emails con promociones y recuperar los detalles de tu cuenta. </br> Simplemente tienes que confirmar tu cuenta haciendo clic</font> <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'><font size=6>aquí!</font></a>.");
                    if (user.Email== "ibuycontrol@mailinator.com")
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                        await _userManager.AddToRoleAsync(user, "Seller");
                        var vendedor = new DetalleVendedor();
                        vendedor.correoComercial = user.Email;
                        vendedor.nombreComercial = "ibuy";
                        vendedor.tipoVendedor = TipoVendedor.Privado;
                        vendedor.tiendaOnlineUserID = user.Id;
                        _context.Add(vendedor);
                    }
                    else {
                        await _userManager.AddToRoleAsync(user, "User");
                        var carrito = new Carrito(user.Id);
                        _context.Add(carrito);
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
                    }                    
                    await _context.SaveChangesAsync();
                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    //return LocalRedirect(returnUrl);
                    //este return redirige luego del registro, hacia la pagina de CheckEmail para informarle de que
                    //debe revisar su bandeja de entrada y validar su cuenta
                    return RedirectToPage("./CheckEmail");
                }
                
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
                
    }
}
