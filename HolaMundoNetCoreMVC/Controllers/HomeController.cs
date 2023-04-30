using HolaMundoNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace HolaMundoNetCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        #region Propiedades
        private readonly ILogger<HomeController> _logger;
        #endregion Propiedades
        
        #region Constructor
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        #endregion

        #region Views
        /// <summary>
        /// Vista para detallar la página principal
        /// </summary>
        /// <returns>IActionResult que regresa el view Index</returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Vista para detallar los términos de privacidad
        /// </summary>
        /// <returns>IActionResult que regresa el view Privacy</returns>
        public IActionResult Privacy()
        {
            return View();
        }
        #endregion Views

        #region Metodos
        /// <summary>
        /// BDOMING 22/04/2023
        /// Creación de método de validación de contraseña, donde se comprueba que cumpla con las condiciones
        /// de una contraseña segura, y que los campos de contraseña no estén vacíos.
        /// </summary>
        /// <param name="Contrasena">string que se obtiene de la vista Index para el primer campo de la contraseña</param>
        /// <param name="RepiteContrasena">string que se obtiene de la vista Index para el segundo campo de la contraseña</param>
        /// <returns>IActionResult que regresa el view Index</returns>
        public IActionResult ValidarTexto(string Contrasena, string RepiteContrasena)
        {
            /* Expresión regular proporcionada por ChatGPT para realizar la validación de la contraseña
             * con las siguientes condiciones:
             *  Al menos una letra mayúscula
             *  Al menos una letra minúscula
             *  Al menos un símbolo
             *  Al menos un número */
            Regex regex = new Regex("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*\\W).+$");

            ViewBag.Message = "La contrasena NO ha sido validada";

            // Condición para validar que los campos no estén vacíos
            if (!String.IsNullOrEmpty(Contrasena) && !String.IsNullOrEmpty(RepiteContrasena))
            {
                if (regex.IsMatch(Contrasena))
                {
                    if (RepiteContrasena.Equals(Contrasena))
                    {
                        ViewBag.Message = "La contrasena ha sido validada";
                    }
                    else
                    {
                        ViewBag.Message = "Las contrasenas que ingresaste no son iguales";
                    }
                }
            }
            else
            {
                ViewBag.Message = "La contrasena NO puede estar vacia"; 
                
            }
            return View("Index");
        }
        #endregion Metodos

        #region  Manejo de errores
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion Manejo de errores
    }
}