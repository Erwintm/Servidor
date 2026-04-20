using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // 1. Cargar la llave del servidor
        FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.FromFile("llave_firebase.json")
        });

        Console.WriteLine("--- ENVIADOR DE MENSAJES PUSH ---");

        // 2. Aquí pegas el token que me pasaste arriba
        string targetToken = "dhWwFOs5QoW0Uhf_4yH8cE:APA91bGfj6srDMVyuZb024YPrhohAQZl75IkHAxhI2OvgnsGY4n_QK7lZQc9CiQSC3scc84TVRKlj95aBk_5K9aatpvQHXwlK6UStlDwrrsW_wSyXztZUUI";

        Console.WriteLine("Escribe el mensaje que quieres enviar al celular:");
        string mensajeUsuario = Console.ReadLine();

        // 3. Crear la notificación
        var message = new Message()
        {
            Token = targetToken,
            Notification = new Notification()
            {
                Title = "¡Mensaje del Servidor!",
                Body = mensajeUsuario
            }
        };

        // 4. Enviar
        try
        {
            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
            Console.WriteLine("Mensaje enviado con éxito: " + response);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al enviar: " + ex.Message);
        }

        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}