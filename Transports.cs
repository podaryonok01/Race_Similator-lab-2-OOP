class Transport {
    public string Name {get; set;}
    public int Speed {get; set;}

    // public Transport(string _name){
    //     Name = _name;
    // }

    public Transport(string _name, int _speed){
        Name = _name;
        Speed = _speed;
    }
}

class GroundTransport:Transport {
    public int TimeBeforeRest {get; set;} // время до остановки

    public Func<int, double> FuncDurationOfRest {get; set;}  // формула для расчета длительности отдыха

    public GroundTransport(string _name,int _speed, int _timeBeforeRest, Func<int, double> _func)
    :base(_name, _speed){
        TimeBeforeRest = _timeBeforeRest;
        FuncDurationOfRest = _func;
    }
    public double DurationOfRest(int _stopNumber) // длительность отдыха; зависит от номера остановки
    {
        return FuncDurationOfRest(_stopNumber);
    } 
}

class AirTransport:Transport {
    public Func<int, double> FuncAccelerationFactor {get; set;}  // формула для коэффициента ускорения

    public AirTransport(string _name,int _speed, Func<int, double> _func)
    :base(_name, _speed){
        FuncAccelerationFactor = _func;
    }

    public double AccelerationFactor(int _distance)  // коэффициент ускорения
    {
        return FuncAccelerationFactor(_distance);
    }
}