class ResultRace {
    public string Name {get; set;}
    public double Time {get; set;}
    public int CountRest {get; set;}

    public ResultRace(string _name, double _time, int _countRest ){
        Name = _name;
        Time = _time;
        CountRest = _countRest;
    }

    public ResultRace(string _name, double _time ){
        Name = _name;
        Time = _time;
    }
}

class RaceSimulator {
    private int Distance;
    private List<Transport> Transports;

    public RaceSimulator(int _distance, List<Transport> _transports){
        Distance = _distance;
        Transports = _transports;
    }

    public List<ResultRace> Start(){
        List<ResultRace> result = new List<ResultRace>();
        Transports.ForEach((tr)=>{
            int dist = Distance;
            if(tr is GroundTransport){
                GroundTransport groundTr = (GroundTransport)tr;
                int RestNumber = 0;
                double Time = 0;
                while(dist > 0){
                    int d = groundTr.TimeBeforeRest * groundTr.Speed;
                    if(d >= dist){
                        Time = Time + dist / groundTr.Speed;
                        
                    }else{
                        Time = Time + d / groundTr.Speed;
                        RestNumber++;
                        Time = groundTr.DurationOfRest(RestNumber);
                    }
                    dist = dist - d;
                }
                result.Add(new ResultRace(groundTr.Name, Math.Round(Time, 2), RestNumber));
            }else if(tr is AirTransport){
                AirTransport airTr = (AirTransport)tr;
                double Time = 0;
                for(int d = 1; d < Distance; d++){
                    double accelerationFactor = airTr.AccelerationFactor(d);
                    Time = Time + (1 / (airTr.Speed * accelerationFactor));
                }
                result.Add(new ResultRace(airTr.Name, Math.Round(Time, 2)));
            }
            
        });

        return result;
    }
}