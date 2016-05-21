using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alumni.DAL;
using Alumni.Model;

namespace Alumni.BLL
{
    public class AlumnusRegBs
    {
        private AlumnusRegDA NewAlumnusRegDA = new AlumnusRegDA();
        string message;
        public IEnumerable<AlumnusRegistration> ListAll()
        {
            return NewAlumnusRegDA.ListAll();
        }


        public IEnumerable<AlumnusRegistration> ListAllByStatus(string status)
        {
            return NewAlumnusRegDA.ListAllByStatus(status);
        }

        public string UpdateStatus(string username, string status)
        {
            return NewAlumnusRegDA.UpdateStatus(username, status);
        }
        public AlumnusRegistration GetById(string id)
        {
            return NewAlumnusRegDA.GetById(id);
        }

        public AlumnusRegistration GetByUsername(string username)
        {
            return NewAlumnusRegDA.GetByUsername(username);
        }

        public string VerifyUsername(string username)
        {
            return NewAlumnusRegDA.VerifyUsername(username);
        }
        public void Insert(AlumnusRegistration AlumnusRegistrationBsObj)
        {
            NewAlumnusRegDA.Insert(AlumnusRegistrationBsObj);
        }

        public void Update(AlumnusRegistration AlumnusRegistrationBsObj)
        {
            var AlumnusExist = NewAlumnusRegDA.GetByUsername(AlumnusRegistrationBsObj.Username);
            AlumnusExist.Surname = AlumnusRegistrationBsObj.Surname;
            AlumnusExist.Othername = AlumnusRegistrationBsObj.Othername;
            AlumnusExist.Sex = AlumnusRegistrationBsObj.Sex;
            AlumnusExist.Dob = AlumnusRegistrationBsObj.Dob;
            AlumnusExist.Marital_Status = AlumnusRegistrationBsObj.Marital_Status;
            AlumnusExist.State = AlumnusRegistrationBsObj.State;
            AlumnusExist.Phone_Number = AlumnusRegistrationBsObj.Phone_Number;
            AlumnusExist.Address = AlumnusRegistrationBsObj.Address;
            AlumnusExist.Department = AlumnusRegistrationBsObj.Department;
            AlumnusExist.Graduation_Year = AlumnusRegistrationBsObj.Graduation_Year;
            AlumnusExist.Email_Id = AlumnusRegistrationBsObj.Email_Id;
            NewAlumnusRegDA.Update(AlumnusExist);
        }

        public AlumnusRegistration Login(string value)
        {
        return  NewAlumnusRegDA.Login(value);
        }

        public string UpdateStatusRole(string Transid, string status, string role)
        {
            NewAlumnusRegDA.UpdateStatusRole(Transid, status, role);
            message = "Record updated successfully";
            return message;
        }
    }
}
