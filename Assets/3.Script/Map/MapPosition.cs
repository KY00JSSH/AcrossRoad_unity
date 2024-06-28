using UnityEngine;

public class MapPosition : MonoBehaviour {
    // �� ĭ�� pos ���� = 2
    public static Vector3Int PosToMapCoord(Vector3 position) {
        // Y���� ������� �����Ƿ� 0���� ����. X, Z ��ǥ�� ���������� ��ȯ�Ͽ� ���� �� return
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