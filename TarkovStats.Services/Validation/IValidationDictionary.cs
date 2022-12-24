namespace TarkovStats.Services.Validation
{
    public interface IValidationDictionary
    {
        string ViewModelPrefix { get; }
        void AddError(string key, string errorMessage);
        bool IsValid { get; }
        void ValidateModel(object instance);
    }
}