using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using UnityEngine;

[DataContract]
public class Player : INotifyPropertyChanged
{
    private int _money;

    [DataMember]
    public int Money
    {
        get { return _money; }
        set
        {
            OnPropertyChanged("Money");
            _money = value;
        }
    }
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
            handler(this, new PropertyChangedEventArgs(propertyName));
    }
    [DataMember]
    public List<UpdateTDO> Updates { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    //public string UserName{get;set;}
}
