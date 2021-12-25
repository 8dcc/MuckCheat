using UnityEngine;

namespace MuckHaxx2
{
    class Main : MonoBehaviour
    {
        bool chest_esp = true;

        public void OnGUI()
        {
            NullsRenderer.DrawWatermark(new Vector2(10f, 20f), new Vector2(110f, 20f), "Null's muck cheat", true);
            //ExtRender.DrawLine(new Vector2(40f, 40f), new Vector2(100f, 40f), Color.red, 2f);

            if (chest_esp)
            {
                foreach (Chest current_chest in UnityEngine.Object.FindObjectsOfType(typeof(Chest)) as Chest[])
                {
                    // ingame pos
                    Vector3 chestPivotPos = current_chest.transform.position;
                    Vector3 chestTop; chestTop.x = chestPivotPos.x; chestTop.z = chestPivotPos.z; chestTop.y = chestPivotPos.y+2f;
                    Vector3 chestBase; chestBase.x = chestPivotPos.x; chestBase.z = chestPivotPos.z; chestBase.y = chestPivotPos.y-2f;

                    // screen pos
                    Vector3 w2s_chestbase = Camera.main.WorldToScreenPoint(chestBase);

                    // Draw line
                    if (w2s_chestbase.z > 0f)
                    {
                        ExtRender.DrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), new Vector2(w2s_chestbase.x, (float)Screen.height - w2s_chestbase.y), Color.red, 1.5f);
                    }
                }
            }
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                Loader.Unload();
            }
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                chest_esp = !chest_esp;
            }
        }
    }
}
