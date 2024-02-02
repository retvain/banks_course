using banks_course;

class Program
{
    // написать консольное приложение, которое для каждой валюты в отдельный файл excel сохраняет курс на указанную дату из разных банков (с каким-нибудь симпатичным форматированием в виде таблички).
    // данные брать из апишек банков: 
    // RUB - https://api.frankfurter.app/latest
    // CZK - https://www.cnb.cz/en/financial_markets/foreign_exchange_market/exchange_rate_fixing/daily.txt?date=27.07.2018
    // EUR - https://api.frankfurter.app/latest
    // иметь в виду, что в будущем могут добавлять новые апишки банков - это не должно выливаться в большие доработки с точки зрения приложения.

    static void Main()
    {
        var application = new Application();
        application.Run();
    }
}