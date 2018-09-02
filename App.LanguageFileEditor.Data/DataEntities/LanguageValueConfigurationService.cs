namespace App.LanguageFileEditor.Data.DataEntities
{
    public class LanguageValueConfigurationService
    {
        public bool GetSharedStatus(int id)
        {
            switch (id)
            {
                // Determine rows that share the same value across languages
                case int n when (n >= 5697 && n <= 5707) || // Teams - Full
                                (n >= 6458 && n <= 6468) || // Teams - Short
                                (n >= 5709 && n <= 5719) || // Teams - Code A
                                (n >= 6487 && n <= 6497) || // Teams - Code B
                                (n >= 5987 && n <= 5997):   // Teams - Chassis
                    return true;
                default:
                    return false;
            }
        }
    }
}