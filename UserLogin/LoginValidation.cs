using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    internal class LoginValidation
    {
        public static UserRoles currentUserRole 
        { get; private set; }

        private string _username;

        private string _password;

        private string? _errorMessage;
        
        public delegate void ActionOnError(string errorMsg);

        private ActionOnError _actionOnError;


        public LoginValidation(string _username,string _password,ActionOnError _actionOnError)
        {
            this._username = _username;
            this._password = _password;
            this._actionOnError = _actionOnError;
        }


        public bool ValidateUserInput(ref User? user)
        {

            if (_username.Length < 5)
            {
                currentUserRole = UserRoles.ANONYMOUS;
                _errorMessage = "Потребителското име е по-късо от пет символа";
                _actionOnError(_errorMessage);
                return false;
            }
            if (_password.Length < 5)
            {
                currentUserRole = UserRoles.ANONYMOUS;
                _errorMessage = "Паролата е по-къса от пет символа";
                _actionOnError(_errorMessage);
                return false;
            }
            if (_username.Equals(String.Empty))
            {
                currentUserRole = UserRoles.ANONYMOUS;
                _errorMessage = "Не е посочено потребителско име";
                _actionOnError(_errorMessage);
                return false;
            }

            if (_password.Equals(String.Empty))
            {
                currentUserRole = UserRoles.ANONYMOUS;
                _errorMessage = "Не е посочена парола";
                _actionOnError(_errorMessage);
                return false;
            }
            user = UserData.IsUserPassCorrect(_username, _password);
            if(user == null)
            {
                currentUserRole = UserRoles.ANONYMOUS;
                _errorMessage = "Невалидно потребителско име или парола";
                _actionOnError(_errorMessage);
                return false;
            }
            else 
            {
                currentUserRole = (UserRoles)user.Role;
                Logger.LogActivity("Успешен Login",_username);
                return true;
            }
        }
    }
}
