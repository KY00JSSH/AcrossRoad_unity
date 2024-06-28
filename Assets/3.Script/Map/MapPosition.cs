using UnityEngine;

public class MapPosition : MonoBehaviour {
    // �� ĭ�� pos ���� = 2

    //public static Vector3Int PosToMapCoord(Vector3 position) {
    //    // Y���� ������� �����Ƿ� 0���� ����. X, Z ��ǥ�� ���������� ��ȯ�Ͽ� ���� �� return
    //    return new Vector3Int(Mathf.RoundToInt(position.x / 2f) , 1, Mathf.RoundToInt(position.z / 2f) );
    //}

    //public static Vector3Int MapCoordToPos(Vector3Int coord) {
    //    return new Vector3Int(coord.x * 2, 1, coord.z * 2);
    //}

    public static Vector3 ToMapCoord(Vector3 position) {
        return new Vector3Int(
            (int)position.x / 2 * 2,
            (int)position.y / 2 * 2,
            (int)position.z / 2 * 2);
    }

    public static Vector3Int ForwardPosition(Vector3 position, Vector3 forward) {
        return new Vector3Int(
            Mathf.RoundToInt(position.x + forward.x * 2) / 2 * 2,
            Mathf.RoundToInt(position.y + forward.y * 2),
            Mathf.RoundToInt(position.z + forward.z * 2) / 2 * 2);
        
    }

    // ��� ������Ʈ ��ġ �� 2�� ����� ���� �ʿ�
}
