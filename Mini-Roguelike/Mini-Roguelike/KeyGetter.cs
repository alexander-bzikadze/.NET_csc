using System;

namespace Mini_Roguelike
{
    internal class KeyGetter
    {
        public event EventHandler<KeyPressedArgs> GotChar;

        public void GetKey(object sender, EventArgs args)
        {   
            var key = Console.ReadKey(true);
            GotChar?.Invoke(this, new KeyPressedArgs(key.Key));
        }
    }
}