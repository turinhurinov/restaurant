namespace Restaurant.Model
{
    public static class ValidationMessages
    {
        public static string NotEmpty => "{0} alanı boş bırakılamaz.";

        public static string BeInRange => "{0} alanı değeri {1} - {2} aralığında olmalıdır.";
    }
}
