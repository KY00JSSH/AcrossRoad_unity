using UnityEngine;

public class MapPosition : MonoBehaviour {
    // 한 칸의 pos 단위 = 2
    public static Vector3Int PosToMapCoord(Vector3 position) {
        // Y축은 사용하지 않으므로 0으로 고정. X, Z 좌표를 정수값으로 변환하여 연산 후 return
        return new Vector3Int(Mathf.RoundToInt(position.x) * 2, 0, Mathf.RoundToInt(position.z) * 2);
    }

    public static Vector3Int MapCoordToPos(Vector3Int coord) {
        return new Vector3Int(coord.x / 2, 0, coord.z / 2);
    }
}

//    public static Vector3Int MapForward(Vector3Int coord, KeyCode key) {
//        switch(key) {
//            case KeyCode.W: return new Vector3Int
//        }
//        return new Vector3Int.
//    }
//}