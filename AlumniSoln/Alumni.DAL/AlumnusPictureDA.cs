using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alumni.Model;
using System.Data.Entity;

namespace Alumni.DAL
{
  public  class AlumnusPictureDA
    {
        private AlumniContext context = new AlumniContext();

        private string message;   
     
        public AlumnusPicture GetByUsername(string username)
        {
            return context.AlumnusPictures.Where(c => c.Username == username).FirstOrDefault();

        }
        public void Insert(AlumnusPicture AlumnusPictureDAObj)
        {
            context.AlumnusPictures.Add(AlumnusPictureDAObj);
            context.SaveChanges();
        }

        public void Update(AlumnusPicture AlumnusPictureDAObj)
        {
            context.Entry(AlumnusPictureDAObj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            var search = context.AlumnusRegistrations.Where(c => c.Username == id).FirstOrDefault();
            context.AlumnusRegistrations.Remove(search);
            context.SaveChanges();
        }

    }
}
