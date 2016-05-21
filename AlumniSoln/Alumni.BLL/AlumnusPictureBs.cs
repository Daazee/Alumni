using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alumni.DAL;
using Alumni.Model;
namespace Alumni.BLL
{
    public class AlumnusPictureBs
    {
        private AlumnusPictureDA NewAlumnusPictureDA = new AlumnusPictureDA();
        string message;

        public AlumnusPicture GetByUsername(string username)
        {
            return NewAlumnusPictureDA.GetByUsername(username);

        }
        public void Insert(AlumnusPicture AlumnusPictureDAObj)
        {
            NewAlumnusPictureDA.Insert(AlumnusPictureDAObj);
        }

        public void Update(AlumnusPicture AlumnusPictureDAObj)
        {
            var AlumnusPicExist = NewAlumnusPictureDA.GetByUsername(AlumnusPictureDAObj.Username);
            AlumnusPicExist.Picture = AlumnusPictureDAObj.Picture;
            AlumnusPicExist.Flag = AlumnusPictureDAObj.Flag;
            NewAlumnusPictureDA.Update(AlumnusPicExist);
        }

        public void Delete(string id)
        {
            NewAlumnusPictureDA.Delete(id);
        }
    }
}
