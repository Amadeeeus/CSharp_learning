emailMessage email = new();
TelegramMessage telegram = new();
Notification note1 = new(email);
Notification note2 =new(telegram);
note1.sendMessage();
note2.sendMessage();
interface IMessage
{
    void send(); 
}
class emailMessage:IMessage
{
public void send()
{
    Console.WriteLine("Sending Email");
}
}
class TelegramMessage:IMessage
{
    public void send()
    {
        Console.WriteLine("Sending telegram...");
    }
}
class Notification
{
    private readonly IMessage _message;
public Notification(IMessage message)
{
_message = message;
}
public void sendMessage()
{
    _message.send();
}
}
