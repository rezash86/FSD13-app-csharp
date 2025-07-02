namespace DelegateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Messenger messenger = new Messenger();
            MessageDelegate messageDelegate =  messenger.ShowMessage;
            //Basic usage
            messageDelegate("it is from a delegate");

            //MultiCast
            messageDelegate += messenger.UpperCaseMessage;
            messageDelegate("Multicast test");

            //delegate as callback
            messenger.ExecuteAction("Reza", messenger.ShowMessage); // sending a reference of a method as the delegate reference
        
            //event delegate
            Alarm alarm = new Alarm();
            alarm.onAlarmTriggered += () => Console.WriteLine("Sound alarm!");
            //subscribes an anonymous mehtod  to the onAlarmTriggerd event
            //when the alram triggers, this method will run and an output "Sound alarm !"

            alarm.Trigger();

            //prints "Alarm tirggerd"
            //then it fires the event -> which calls the subscribed method
            // Result -> "sound alarm !" is also printed
        }

        private static void Alarm_onAlarmTriggered()
        {
            throw new NotImplementedException();
        }
    }

    delegate void MessageDelegate(string message);
    class Messenger
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine("Message " + message);
        }
        public void UpperCaseMessage(string message)
        {
            Console.WriteLine("Upper " + message.ToUpper());
        }

        public void ExecuteAction(string name, MessageDelegate messageDelegate)
        {
            messageDelegate("Hello " + name);
        }
    }

    class Alarm
    {
        //action is a built-in delegate -> delegate void something()
        public event Action onAlarmTriggered;
        
        //This event allows other parts of the code to subscribe methods that will be 
        //called when the alarm is triggerd


        public void Trigger()
        {
            Console.WriteLine("Alarm Triggerd");
            onAlarmTriggered?.Invoke(); //it invokes all subscribed methods
        }
    }
}
    