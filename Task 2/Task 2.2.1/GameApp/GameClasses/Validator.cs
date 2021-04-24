using System;
using System.Collections.Generic;
using System.Text;

namespace GameClasses
{
    public static class Validator
    {
        /// <summary>
        /// Метод, проверяющий не вышел ли грок за игровое поле.
        /// </summary>
        /// <param name="coordintaXplayer"></param>
        /// <param name="coordintaYplayer"></param>
        /// <param name="fieldXborder"></param>
        /// <param name="fieldYborder"></param>
        /// <returns>Булево значение, в зависимости от результатов проверки.</returns>
        public static bool CheckingPositionOfThePlayerAndBordersOfTheField(int coordinatplayer, int speed, int fieldborder, int action)
        {
            switch (action)
            {
                case 1:
                    if (coordinatplayer + speed > fieldborder) return false;
                    else return true;
                case 2:
                    if (coordinatplayer - speed < fieldborder) return false;
                    else return true;
                case 3:
                    if (coordinatplayer - speed < fieldborder) return false;
                    else return true;
                case 4:
                    if (coordinatplayer + speed > fieldborder) return false;
                    else return true;
                default:
                    return false;
            }
        }
    }
}
