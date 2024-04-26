using Dummiesman;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class ObjFromStream : MonoBehaviour {
	

void Start () {
        //make UnityWebRequest
        var request = UnityWebRequest.Get("https://people.sc.fsu.edu/~jburkardt/data/obj/lamp.obj");
        request.SendWebRequest();
        while (!request.isDone)
            System.Threading.Thread.Sleep(1);
        
        //create stream and load
        var textStream = new MemoryStream(Encoding.UTF8.GetBytes(request.downloadHandler.text));
        var loadedObj = new OBJLoader().Load(textStream);
    }

}