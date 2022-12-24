using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TarkovStats.Services.Validation
{
    public class ModelStateWrapper : IValidationDictionary
    {
        private ModelStateDictionary _modelState;

        public ModelStateWrapper(ModelStateDictionary modelState, string viewModelPrefix = "")
        {
            _modelState = modelState;
            ViewModelPrefix = viewModelPrefix;
        }

        #region IValidationDictionary Members

        public string ViewModelPrefix { get; }

        public void AddError(string key, string errorMessage)
        {
            _modelState.AddModelError(GetKey(key), errorMessage);
        }

        public bool IsValid
        {
            get { return _modelState.IsValid; }
        }

        public void ValidateModel(object instance)
        {
            _modelState.Clear();
            var vc = new ValidationContext(instance);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(instance, vc, results);
            foreach (var result in results)
            {
                foreach (var memberName in result.MemberNames)
                {
                    _modelState.AddModelError(GetKey(memberName),result?.ErrorMessage??"");
                }
            }
        }

        private string GetKey(string memberName)
        {
            if (string.IsNullOrWhiteSpace(ViewModelPrefix))
            {
                return memberName;
            }

            return ViewModelPrefix + memberName;
        }

        #endregion
    }
}