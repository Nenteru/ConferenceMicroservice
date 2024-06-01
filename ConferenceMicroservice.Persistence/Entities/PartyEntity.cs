namespace ConferenceMicroservice.Persistence.Entities;

public class PartyEntity
{
    public Guid Id { get; set; }
    
    public DateTime DateTimeUserAdd { get; set; }

    // User part
    public Guid UserId { get; set; }
    public UserEntity? User { get; set; }

    //Chat part
    public Guid ChatId { get; set; }
    public ChatEntity? Chat { get; set; }

    // Message part
    public ICollection<MessageEntity> Messages { get; set; } = [];
}

////SMO1 Многоканальные с отказами чистая
//public class SMO1
//{
//    public double lambda { get; set; }
//    public double Tobs { get; set; }
//    public int n { get; set; }

//    public SMO1(double lambda, double Tobs, int n)
//    {
//        this.lambda = lambda;//Интенсивность потока заявок
//        this.Tobs = Tobs;//Интенсивность обслуживания для всех каналов
//        this.n = n;//Количество каналов

//        mu = CalculateMu(Tobs);
//        rho = CalculateRho(lambda, Tobs);
//        P0 = CalculatePk(0, lambda, n, Tobs);
//        Potk = CalculatePotk(lambda, n, Tobs);
//        Pobs = CalculatePobs(lambda, n, Tobs);

//        Q = CalculateQ(lambda, n, Tobs);
//        A = CalculateA(lambda, n, Tobs);
//        V = CalculateV(lambda, n, Tobs);
//        K = CalculateK(lambda, n, Tobs);
//        Tsis = CalculateTsis(lambda, n, Tobs);
//    }
//    public double Factorial(double n)
//    {
//        if (n == 0)
//            return 1;
//        else
//            return n * Factorial(n - 1);
//    }
//    public double mu { get; set; }
//    public double CalculateMu(double Tobs)
//    {
//        return 1 / Tobs;
//    }
//    //Показатель нагрузки системы
//    public double rho { get; set; }

//    public double CalculateRho(double lambda, double Tobs)
//    {
//        double mu = CalculateMu(Tobs);
//        return lambda / mu;
//    }
//    public double P0 { get; set; }

//    public double CalculateP0(double lambda, int n, double Tobs)
//    {
//        double rho = CalculateRho(lambda, Tobs);

//        double P0 = 0;
//        for (int k = 0; k <= n; k++)
//        {
//            P0 += (Math.Pow(rho, k)) / (Factorial(k));
//        }
//        return Math.Pow(P0, (-1));
//    }

//    //Вероятность различных состояний системы массового обслуживания
//    public double CalculatePk(double k, double lambda, int n, double Tobs)
//    {
//        double rho = CalculateRho(lambda, Tobs);
//        double P0 = CalculateP0(lambda, n, Tobs);
//        return ((Math.Pow(rho, k)) / (Factorial(k))) * P0;
//    }
//    //Вероятность отказа заявке в обслуживание
//    public double Potk { get; set; }
//    public double CalculatePotk(double lambda, int n, double Tobs)
//    {
//        double rho = CalculateRho(lambda, Tobs);
//        double P0 = CalculateP0(lambda, n, Tobs);
//        return ((Math.Pow(rho, n)) / (Factorial(n))) * P0;
//    }
//    //Вероятность того, что пришедшая заявка будет обслужена
//    public double Pobs { get; set; }
//    public double CalculatePobs(double lambda, int n, double Tobs)
//    {
//        double Potk = CalculatePotk(lambda, n, Tobs);
//        return 1 - Potk;
//    }
//    //Относительная пропускная способность
//    public double Q { get; set; }
//    public double CalculateQ(double lambda, int n, double Tobs)
//    {
//        return CalculatePobs(lambda, n, Tobs);
//    }
//    //Абсолютная пропускная способность 
//    public double A { get; set; }
//    public double CalculateA(double lambda, int n, double Tobs)
//    {
//        double Q = CalculateQ(lambda, n, Tobs);
//        double mu = CalculateMu(Tobs);
//        return mu * Q;
//    }
//    //Интенсивность V выходящего потока обслуженных заявок
//    public double V { get; set; }
//    public double CalculateV(double lambda, int n, double Tobs)
//    {
//        double A = CalculateA(lambda, n, Tobs);
//        return A;
//    }

//    //Среднее число занятых каналов обслуживания
//    public double K { get; set; }
//    public double CalculateK(double lambda, int n, double Tobs)
//    {
//        double A = CalculateA(lambda, n, Tobs);
//        double mu = CalculateMu(Tobs);
//        return A / mu;
//    }
//    //Среднее время пребывания заявки в системе (формула Литтла)
//    public double Tsis { get; set; }
//    public double CalculateTsis(double lambda, int n, double Tobs)
//    {
//        double Q = CalculateQ(lambda, n, Tobs);
//        return Tobs * Q;
//    }
//}