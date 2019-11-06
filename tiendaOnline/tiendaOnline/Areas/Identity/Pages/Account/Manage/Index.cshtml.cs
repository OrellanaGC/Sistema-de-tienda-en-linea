using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using tiendaOnline.Areas.Identity.Data;

namespace tiendaOnline.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<tiendaOnlineUser> _userManager;
        private readonly SignInManager<tiendaOnlineUser> _signInManager;
        private readonly IEmailSender _emailSender;

        public IndexModel(
            UserManager<tiendaOnlineUser> userManager,
            SignInManager<tiendaOnlineUser> signInManager,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress (ErrorMessage ="Escriba un correo electronico valido")]
            public string Email { get; set; }
            [Phone (ErrorMessage ="Escriba un numero valido")]
            [Display(Name = "Numero de telefono")]
            public string PhoneNumber { get; set; }
            [Display(Name ="Apellidos")]
            public string Apellidos { get; set; }
            
        }

        //Muestra los datos del usuario por get
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"No se pudo cargar al usuarion con ID '{_userManager.GetUserId(User)}'.");
            }

            var userName = await _userManager.GetUserNameAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var apellidos = user.apellidos;
            
            Username = userName;

            Input = new InputModel
            {
                Email = email,
                PhoneNumber = phoneNumber,
                Apellidos = apellidos,

            };

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            return Page();
        }

        //Actualiza los datos del usuario por post
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);            
            if (user == null)
            {
                return NotFound($"No se pudo cargar al usuario con ID '{_userManager.GetUserId(User)}'.");
            }

            var email = await _userManager.GetEmailAsync(user);
            if (Input.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"error inesperado ocurrio al establecer el correo electronico para el usuario con ID '{userId}'.");
                }
            }
            //Cambia el numero y valida si la informacion es correcta
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);                
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"error inesperado ocurrio al establecer el numero para el usuario con ID '{userId}'.");
                }
            }
            //Agregando/cambiando el apellido de usuario
            var apellidos = user.apellidos;
           

            if(Input.Apellidos != apellidos)
            {
                user.Apellidos= Input.Apellidos;

            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Su perfil ha sido actualizado";
            return RedirectToPage();
        }

        //Mandar verificacion de email
        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"No su pudo cargar al usuarion con ID '{_userManager.GetUserId(User)}'.");
            }


            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Confirmar su correo electronico",
                $"Por favor confirmar su cuenta <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>presionando aca</a>.");

            StatusMessage = "Correo de verificacion enviado, por favor revisar su correo.";
            return RedirectToPage();
        }
    }
}
