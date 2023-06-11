using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class MoneySpawner : MonoBehaviour
{
    [SerializeField] private List<MoneySO> _moneyTypes = new List<MoneySO>();

    protected virtual void Start()
    {
        SpawnMoney();
    }

    private async void SpawnMoney()
    {
        await SpawnInInterval(2000);
        Debug.Log("Spawning Money");

        SpawnMoney();
    }
    private async Task SpawnInInterval(int time)
    {
       // yield return new WaitForSeconds(time);
       await Task.Delay(time);

        
    }
}
