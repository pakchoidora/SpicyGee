using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace spicygee
{
    public class SoundManager {

        private static SoundManager instance = null;

        public static SoundManager GetInstance() {
            if (instance == null) {
                instance = new SoundManager();
            }
            return instance;
        }
    }
}
