using CountryWeatherAPI.Models.DTOs.Request;
using PhoneNumbers;

namespace CountryWeatherAPI.Business.Concrete;

public class ResponsiblePersonBusinessValidation
{
    public static void AddResponsiblePersonValidation(ResponsiblePersonPostDto dto)
        {
            if (dto == null)
                throw new Exception("Request cannot be empty.");

            if (string.IsNullOrWhiteSpace(dto.FirstName))
                throw new Exception("First name cannot be empty.");
            
            if (dto.FirstName.Length > 64)
                throw new Exception("First name cannot be more than 64 characters.");
            
            if (dto.FirstName.Length < 3)
                throw new Exception("First name cannot be less than 3 characters.");
            
            if (string.IsNullOrWhiteSpace(dto.LastName))
                throw new Exception("Last name cannot be empty.");
            
            if (dto.LastName.Length > 64)
                throw new Exception("Last name cannot be more than 64 characters.");
            
            if (dto.LastName.Length < 3)
                throw new Exception("Last name cannot be less than 3 characters.");
            
            if (string.IsNullOrWhiteSpace(dto.Email))
                throw new Exception("Email cannot be empty.");
            
            if (!IsValidEmail(dto.Email))
                throw new Exception("Invalid email format.");


            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            try
            {
                var phoneNumberProto = phoneNumberUtil.Parse(dto.PhoneNumber, null);
                if (!phoneNumberUtil.IsValidNumber(phoneNumberProto))
                {
                    throw new Exception("Invalid phone number format.");
                }
            }
            catch (NumberParseException)
            {
                throw new Exception("Invalid phone number format.");
            }
        }
    
        public static void ValidateAssignment(ResponsiblePersonAssignmentDto dto)
        {
            if (dto == null)
                throw new Exception("Request cannot be empty.");

            if (dto.ResponsiblePersonId <= 0)
                throw new Exception("Invalid Responsible Person ID.");

            if (dto.CountryId <= 0)
                throw new Exception("Invalid Country ID.");
        }

        public static void ValidateDeassignment(ResponsiblePersonAssignmentDto dto)
        {
            if (dto == null)
                throw new Exception("Request cannot be empty.");

            if (dto.ResponsiblePersonId <= 0)
                throw new Exception("Invalid Responsible Person ID.");

            if (dto.CountryId <= 0)
                throw new Exception("Invalid Country ID.");
        }

        public static void ValidateUpdate(int id, ResponsiblePersonPutDto dto)
        {
            if (id != dto.Id)
                throw new Exception("ResponsiblePerson ID mismatch.");

            if (string.IsNullOrWhiteSpace(dto.FirstName))
                throw new Exception("First name cannot be empty.");
            
            if (dto.FirstName.Length > 64)
                throw new Exception("First name cannot be more than 64 characters.");
            
            if (dto.FirstName.Length < 3)
                throw new Exception("First name cannot be less than 3 characters.");
            
            if (string.IsNullOrWhiteSpace(dto.LastName))
                throw new Exception("Last name cannot be empty.");
            
            if (dto.LastName.Length > 64)
                throw new Exception("Last name cannot be more than 64 characters.");
            
            if (dto.LastName.Length < 3)
                throw new Exception("Last name cannot be less than 3 characters.");
            
            if (string.IsNullOrWhiteSpace(dto.Email))
                throw new Exception("Email cannot be empty.");
            
            if (!IsValidEmail(dto.Email))
                throw new Exception("Invalid email format.");
            
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            try
            {
                var phoneNumberProto = phoneNumberUtil.Parse(dto.PhoneNumber, null);
                if (!phoneNumberUtil.IsValidNumber(phoneNumberProto))
                {
                    throw new Exception("Invalid phone number format.");
                }
            }
            catch (NumberParseException)
            {
                throw new Exception("Invalid phone number format.");
            }
        }

        public static void ValidateDeletion(int id)
        {
            if (id <= 0)
                throw new Exception("Invalid Responsible Person ID.");
        }


        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
}