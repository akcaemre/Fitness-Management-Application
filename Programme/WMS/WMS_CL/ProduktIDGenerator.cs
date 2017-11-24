namespace WMS_CL
{
    public static class ProduktIDGenerator
    {
        private static int _id = 0;
        public static int ID { get
            {
                return _id++;
            }
        }

        static void setID (int newID)
        {
            if(newID > _id)
                _id = newID;
        }
    }
}
