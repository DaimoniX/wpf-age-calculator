using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFAgeCalculator;

public class AgeViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    
    private int _age;
    private DateTime _date = DateTime.Today;

    public int Age
    {
        get => _age;
        private set
        {
            _age = value;
            OnPropertyChanged();
        }
    }
    
    public DateTime Date
    {
        get => _date;
        set
        {
            _date = value;
            Age = (DateTime.Now - _date).Days / 365;
            OnPropertyChanged();
        }
    }
    
    public bool IsValidBirthDate()
    {
        return Date <= DateTime.Today && Age < 135;
    }

    public bool IsBirthdayToday()
    {
        var now = DateTime.Now;
        return now.Month == Date.Month && now.Day == Date.Day;
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}