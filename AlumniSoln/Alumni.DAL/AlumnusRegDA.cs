using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Alumni.Model;

namespace Alumni.DAL
{
 public  class AlumnusRegDA
    {
        private AlumniContext context = new AlumniContext();

        private string message;
        public IEnumerable<AlumnusRegistration> ListAll()
        {
            return context.AlumnusRegistrations.ToList(); // to not include admin

        }

        public IEnumerable<AlumnusRegistration> ListAllByStatus(string status)
        {
            return context.AlumnusRegistrations.Where(c => c.Reg_Status == status).ToList();
        }

        public string UpdateStatus(string username, string status)
        {
            var search = context.AlumnusRegistrations.Where(c => c.Username == username).FirstOrDefault();
            search.Reg_Status = status;
            context.SaveChanges();
            message = "Status updated successfully";
            return message;
        }
        public AlumnusRegistration GetById(string id)
        {
            return context.AlumnusRegistrations.Where(c => c.AlumnusRegistration_Id == id).FirstOrDefault();
        }

        public AlumnusRegistration GetByUsername(string username)
        {
            return context.AlumnusRegistrations.Where(c => c.Username == username).FirstOrDefault();

        }
        public string VerifyUsername(string username)
        {
            var search = context.AlumnusRegistrations.Where(c => c.Username == username).FirstOrDefault();
            if (search != null)
            {
                message = "Username already exist";
            }
            else
            {
                message = "";
            }
            return message;
        }
        public void Insert(AlumnusRegistration AlumnusRegistrationDAObj)
        {
            context.AlumnusRegistrations.Add(AlumnusRegistrationDAObj);
            context.SaveChanges();
        }

        public void Update(AlumnusRegistration AlumnusRegistrationDAObj)
        {
            context.Entry(AlumnusRegistrationDAObj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            var search = context.AlumnusRegistrations.Where(c => c.Username == id).FirstOrDefault();
            context.AlumnusRegistrations.Remove(search);
            context.SaveChanges();
        }

        public AlumnusRegistration Login(string value)
        {
            var search = context.AlumnusRegistrations.Where(c => c.Username == value || c.Email_Id==value).FirstOrDefault();
            return search;
        }

        public void UpdateStatusRole(string username, string status, string role)
        {
            var search = GetByUsername(username);
            search.Reg_Status = status;
            search.Alumnus_Role = role;
            context.SaveChanges();
        }

    }
}
