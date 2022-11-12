using System;

namespace OrderBot
{
    public class Session
    {
        private enum State
        {
            WELCOMING, BOOK, SERVICE
        }

        private State nCur = State.WELCOMING;
        private Order oOrder;

        public Session(string sPhone)
        {
            this.oOrder = new Order();
            this.oOrder.Phone = sPhone;
        }

        public List<String> OnMessage(String sInMessage)
        {
            List<String> aMessages = new List<string>();
            switch (this.nCur)
            {
                case State.WELCOMING:
                    aMessages.Add("Welcome to Dental Clinic!");
                    aMessages.Add("Are you looking for an appointment?");
                    this.nCur = State.BOOK;
                    break;
                case State.BOOK:
                    this.oOrder.Size = sInMessage;
                    this.oOrder.Save();
                    aMessages.Add("Which date would you like the appointment?");
                    this.nCur = State.SERVICE;
                    break;
                case State.SERVICE:
                    string sSERVICE = this.oOrder.Service = sInMessage;
                    this.oOrder.Save();
                    aMessages.Add("Do you need regular cleaning appointment " + " " + sSERVICE + " ?");
                    break;


            }
            aMessages.ForEach(delegate (String sMessage)
            {
                System.Diagnostics.Debug.WriteLine(sMessage);
            });
            return aMessages;
        }

    }
}
