using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFAgeCalculator;

public class AgeViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    
    private int _age;
    private string _westernZodiacSign = string.Empty;
    private string _chineseZodiacSign = string.Empty;
    private DateTime _date = DateTime.Today;

    public int Age
    {
        get => _age;
        private set
        {
            if(value == _age) return;
            _age = value;
            OnPropertyChanged();
        }
    }
    
    public DateTime Date
    {
        get => _date;
        set
        {
            if (value == _date) return;
            _date = value;
            Age = (DateTime.Now - _date).Days / 365;
            WesternZodiacSign = ZodiacSign.GetWesternSign(_date);
            ChineseZodiacSign = ZodiacSign.GetChineseSign(_date);
            OnPropertyChanged();
        }
    }
    
    public string WesternZodiacSign
    {
        get => _westernZodiacSign;
        private set
        {
            if (value == _westernZodiacSign) return;
            _westernZodiacSign = value ?? throw new ArgumentNullException(nameof(value));
            OnPropertyChanged();
        }
    }

    public string ChineseZodiacSign
    {
        get => _chineseZodiacSign;
        private set
        {
            if (value == _chineseZodiacSign) return;
            _chineseZodiacSign = value ?? throw new ArgumentNullException(nameof(value));
            OnPropertyChanged();
        }
    }
    
    public bool IsValidBirthDate()
    {
        return Date <= DateTime.Today && Age < 135;
    }

    public bool IsBirthdayToday()
    {
        var now = DateTime.Today;
        return now.Month == Date.Month && now.Day == Date.Day;
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}