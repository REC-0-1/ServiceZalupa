using System.ComponentModel;

public class Offers : INotifyPropertyChanged
{
    private int _id;
    private string _name;
    private string _number;
    private string _mark;
    private int _partnumber;
    private int _price;
    private bool _approved;

    public int Id
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged(nameof(Id));
        }
    }

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public string number
    {
        get => _number;
        set
        {
            _number = value;
            OnPropertyChanged(nameof(number));
        }
    }

    public string Mark
    {
        get => _mark;
        set
        {
            _mark = value;
            OnPropertyChanged(nameof(Mark));
        }
    }

    public int partnumber
    {
        get => _partnumber;
        set
        {
            _partnumber = value;
            OnPropertyChanged(nameof(partnumber));
        }
    }

    public int price
    {
        get => _price;
        set
        {
            _price = value;
            OnPropertyChanged(nameof(price));
        }
    }

    public bool Approved
    {
        get => _approved;
        set
        {
            _approved = value;
            OnPropertyChanged(nameof(Approved));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}