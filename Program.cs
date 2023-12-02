class Program {

    static int[] GetGroundTransports() {
        bool isRead = true;
        int[] validValues = { 1, 2, 3, 4 };
        
        Console.WriteLine("  1 - Сапоги-скороходы");
        Console.WriteLine("  2 - Карета-тыква");
        Console.WriteLine("  3 - Избушка на курьих ножках");
        Console.WriteLine("  4 - Кентавр");
        int[] res = {};
        while(isRead){
            List<int> notValid = new List<int>();
            res = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            foreach(int item in res){
                if(!validValues.Contains(item)){
                    notValid.Add(item);
                }
            }
            if(notValid.Count > 0){
                Console.WriteLine(
                    "Введенные значения не входят в допустимый диапазон(" + string.Join(", ", notValid) + "). Введите заново:"
                );
            }else{
                if(res.ToList().Count < 2){
                    Console.WriteLine(
                        "В гонке должно участвовать минимум два транспортных средства! Введите заново:"
                    );
                }else{
                    isRead = false;
                }
            }
        }
        return res;
    }

    static int[] GetAirTransports() {
        bool isRead = true;
        int[] validValues = { 5, 6, 7, 8 };
        Console.WriteLine("  5 - Ступа Бабы Яги");
        Console.WriteLine("  6 - Метла");
        Console.WriteLine("  7 - Ковер-самолет");
        Console.WriteLine("  8 - Летучий корабль");
        int[] res = {};
        while(isRead){
            List<int> notValid = new List<int>();
            res = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            foreach(int item in res){
                if(!validValues.Contains(item)){
                    notValid.Add(item);
                }
            }
            if(notValid.Count > 0){
                Console.WriteLine(
                    "Введенные значения не входят в допустимый диапазон(" + string.Join(", ", notValid) + "). Введите заново:"
                );
            }else{
                if(res.ToList().Count < 2){
                    Console.WriteLine(
                        "В гонке должно участвовать минимум два транспортных средства! Введите заново:"
                    );
                }else{
                    isRead = false;
                }
            }
        }
        return res;
    }

    static int[] GetTransports() {
        bool isRead = true;
        int[] validValues = { 1, 2, 3, 4, 5, 6, 7, 8 };
        Console.WriteLine("  1 - Сапоги-скороходы");
        Console.WriteLine("  2 - Карета-тыква");
        Console.WriteLine("  3 - Избушка на курьих ножках");
        Console.WriteLine("  4 - Кентавр");
        Console.WriteLine("  5 - Ступа Бабы Яги");
        Console.WriteLine("  6 - Метла");
        Console.WriteLine("  7 - Ковер-самолет");
        Console.WriteLine("  8 - Летучий корабль");
        int[] res = {};
        while(isRead){
            List<int> notValid = new List<int>();
            res = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            foreach(int item in res){
                if(!validValues.Contains(item)){
                    notValid.Add(item);
                }
            }
            if(notValid.Count > 0){
                Console.WriteLine(
                    "Введенные значения не входят в допустимый диапазон(" + string.Join(", ", notValid) + "). Введите заново:"
                );
            }else{
                if(res.ToList().Count < 2){
                    Console.WriteLine(
                        "В гонке должно участвовать минимум два транспортных средства! Введите заново:"
                    );
                }else{
                    isRead = false;
                }
            }
        }
        return res;
    }

    static Transport CreateTransport(int idTr){
        switch(idTr){
            case 1: return new GroundTransport("Сапоги-скороходы", 25, 3, TransportFunction.Func1);
            case 2: return new GroundTransport("Карета-тыква", 20, 5, TransportFunction.Func2);
            case 3: return new GroundTransport("Избушка на курьих ножках", 15, 7, TransportFunction.Func3);
            case 4: return new GroundTransport("Кентавр", 20, 10, TransportFunction.Func4);
            case 5: return new AirTransport("Ступа Бабы Яги", 30, TransportFunction.Func5);
            case 6: return new AirTransport("Метла", 25, TransportFunction.Func6);
            case 7: return new AirTransport("Ковер-самолет", 20, TransportFunction.Func7);
            case 8: return new AirTransport("Летучий корабль", 25, TransportFunction.Func8);
            default: return new Transport("Неизвестный транспорт", 0);
        }
    }
    static void Main() {
        Console.WriteLine("Укажите дистанцию гонки:");
        int dist;
        try{
            dist = Int32.Parse(Console.ReadLine());
        }catch(FormatException e){
            Console.WriteLine(e.Message);
            return;
        }

        Console.WriteLine("Укажите тип гонки:");
        Console.WriteLine("  1 - Для наземного транспорта");
        Console.WriteLine("  2 - Для воздушного транспорта");
        Console.WriteLine("  3 - Для всех типов транспорта");

        int typeRice;
        try{
            typeRice = Int32.Parse(Console.ReadLine());
        }catch(FormatException e){
            Console.WriteLine(e.Message);
            return;
        }

        List<int> transports;

        Console.WriteLine("Выберите транспорт (введите номера через пробел):");

        switch(typeRice){
            case 1: {
                transports = GetGroundTransports().ToList();
                break;
            }
            case 2: {
                transports = GetAirTransports().ToList();
                break;
            }
            case 3: {
                transports = GetTransports().ToList();
                break;
            }
            default:{
                Console.WriteLine("Введенные данные некорректны");
                return;
            }
        }

        List<Transport> transportsList = new List<Transport>();
        transports.ForEach((tr)=>{
            transportsList.Add(CreateTransport(tr));
        });

        RaceSimulator rs = new RaceSimulator(dist, transportsList);
        List<ResultRace> result = rs.Start();
        int i = 1;

        result.Sort(delegate(ResultRace x, ResultRace y) {
            return x.Time.CompareTo(y.Time);
        });

        result.ForEach((r)=>{
            string res = i + ". " + r.Name + " (Время: " + r.Time + " ; Кол-во остановок: " + r.CountRest + ")";
            Console.WriteLine(res);
            i++;
        });
    }
}
