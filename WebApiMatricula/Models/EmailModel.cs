using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMatricula.Models
{
    public class EmailModel
    {

        public string email { get; set; }

        public int idUsuario { get; set; }

        public List<EmailModel> obtenerEmails(List<Emails> tempEmails)
        {
            try
            {
                List<EmailModel> emails = new List<EmailModel>();
                foreach (Emails email in tempEmails)
                {
                    EmailModel temp = new EmailModel();
                    temp.email = email.Email;
                    temp.idUsuario = email.idUsuario;

                    emails.Add(temp);
                }

                return emails;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}