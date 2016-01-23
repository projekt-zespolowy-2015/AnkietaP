using System;
using System.ComponentModel.DataAnnotations;

namespace BlogApplication.Validators
{
    public class IsPesel : ValidationAttribute
    {
        public string Sex { get; private set; }

        public IsPesel()
        {
            Sex = null;
        }

        public IsPesel(string sex)
        {
            Sex = sex;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string errorMessage;
            string pesel;

            if (validationContext.DisplayName == null)
                errorMessage = "Numer PESEL jest niepoprawny";
            else
                errorMessage = FormatErrorMessage(validationContext.DisplayName);

            // jeżeli pole jest puste zwracamy wartość 'Success', ponieważ
            // za określenie czy to pole ma być wymagane służy atrybut 'Required'
            if (value == null)
                return ValidationResult.Success;

            // sprawdzamy czy PESEL zawiera się w polu typu 'string'
            if (value is string)
                pesel = value.ToString();
            else
                return new ValidationResult("Typ pola przechowujący PESEL nie jest typu 'string'");

            if (pesel.Length != 11) // jeżeli ciąg posiada więcej lub mniej niż 11 znaków wyświetlamy komunikat o błędzie
                return new ValidationResult(errorMessage);


            int[] weight = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int k = 0;

            for (int i = 0; i < pesel.Length; i++)
            {
                int temp;

                if (!Int32.TryParse(pesel[i].ToString(), out temp)) // jeżeli któryś ze znaków nie jest cyfrą wyświetlamy komunikat o błędzie
                    return new ValidationResult(errorMessage);

                if (i + 1 == pesel.Length)
                {
                    if ((10 - k % 10) % 10 != temp) // jeżeli suma kontrolna jest niepoprawna wyświetlamy komunikat o błędzie
                        return new ValidationResult(errorMessage);
                }
                else
                    k += temp * weight[i];
            }

            if (Sex != null) // jeżeli walidacja ma podany odpowiedni parametr, sprawdzamy poprawność płci
            {
                int n = Convert.ToInt32(pesel[9].ToString());

                switch (Sex)
                {
                    // część ta wykonuje sie gdy parametrem jest 'k' lub 'm'
                    case "k":
                        if (n%2 != 0)
                            return new ValidationResult("Nie jesteś kobietą");
                        break;

                    case "m":
                        if (n%2 != 1)
                            return new ValidationResult("Nie jesteś mężczyzną");
                        break;

                    // część ta wykonuje się gdy parametrem jest pole z klasy
                    default:
                        var sexInfo = validationContext.ObjectType.GetProperty(Sex);
                        var sexValue = (string)sexInfo.GetValue(validationContext.ObjectInstance, null);

                        switch (sexValue)
                        {
                            case "k":
                                if (n % 2 != 0)
                                    return new ValidationResult("Nie jesteś kobietą");
                                break;

                            case "m":
                                if (n % 2 != 1)
                                    return new ValidationResult("Nie jesteś mężczyzną");
                                break;
                        }
                        break;
                }
            }

            return ValidationResult.Success;
        }
    }
}