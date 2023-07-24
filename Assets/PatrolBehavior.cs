using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : MonoBehaviour
{
    [SerializeField] private List<Transform> patrolPoints; // Список точек патрулирования
    [SerializeField] private float speed = 5f; // Скорость перемещения
    [SerializeField] private float waitTime = 2f; // Время ожидания перед следующей точкой

    private int currentPointIndex = 0; // Индекс текущей точки патрулирования
    private Transform currentPoint; // Текущая точка патрулирования
    private Transform player; // Игрок (для определения направления движения)

    private bool isMoving = true; // Флаг, определяющий, движется ли юнит в данный момент
    private bool isWaiting = false; // Флаг, определяющий, ожидает ли юнит перед следующей точкой

    private void Start()
    {
        // Проверяем, что заданы хотя бы 2 точки патрулирования
        if (patrolPoints.Count < 2)
        {
            Debug.LogError("Необходимо задать хотя бы 2 точки патрулирования.");
            return;
        }

        currentPoint = patrolPoints[currentPointIndex]; // Устанавливаем текущую точку патрулирования
        player = transform; // Игрок - сам юнит

        StartCoroutine(Patrol()); // Запускаем корутину патрулирования
    }

    private IEnumerator Patrol()
    {
        while (true)
        {
            if (isMoving)
            {
                // Вычисляем направление движения до текущей точки
                Vector3 direction = (currentPoint.position - player.position).normalized;
                player.Translate(direction * speed * Time.deltaTime); // Двигаем юнит к точке

                // Если юнит приблизился достаточно близко к текущей точке, останавливаем его и начинаем ожидание
                if (Vector3.Distance(player.position, currentPoint.position) < 0.5f)
                {
                    player.position = currentPoint.position; // Ставим юнит точно на место текущей точки
                    isMoving = false; // Останавливаем движение
                    isWaiting = true; // Начинаем ожидание
                    yield return new WaitForSeconds(waitTime); // Ожидаем указанное время
                }
            }
            else if (isWaiting)
            {
                // Переходим к следующей точке патрулирования
                currentPointIndex = (currentPointIndex + 1) % patrolPoints.Count;
                currentPoint = patrolPoints[currentPointIndex]; // Обновляем текущую точку патрулирования

                isMoving = true; // Начинаем движение
                isWaiting = false; // Заканчиваем ожидание
            }

            yield return null;
        }
    }
}
