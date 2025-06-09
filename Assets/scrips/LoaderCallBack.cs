using UnityEngine;

public class LoaderCallBack : MonoBehaviour
{
    private bool isFirstIpdate = true;

    private void Update()
    {
        if (isFirstIpdate)
        {
            isFirstIpdate=false;

            Loader.LoaderCallBack();
        }
    }
}
