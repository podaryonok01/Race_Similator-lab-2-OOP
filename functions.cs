static class TransportFunction{

    public static double Func1(int _time){
        return 5 + _time;
    }

    public static double Func2(int _time){
        return 2 * _time;
    }

    public static double Func3(int _time){
        return Math.Pow(_time, 1/2);
    }

    public static double Func4(int _time){
        return 5 * (Math.Abs(Math.Cos(_time)) + 1);
    }

    public static double Func5(int _dist){
        return (Math.Abs(Math.Cos(_dist)) + 1) * Math.Pow(_dist, 2);
    }

    public static double Func6(int _dist){
        return (Math.Abs(Math.Sin(_dist)) + 1) * (Math.Abs(Math.Tan(_dist)) + 1);
    }

    public static double Func7(int _dist){
        return (5 * Math.Abs(Math.Sin(_dist)) + 2) / 2;
    }

    public static double Func8(int _dist){
        return Math.Pow(_dist, 1.5) * Math.Abs(Math.Sin(_dist)) + 1;
    }
}