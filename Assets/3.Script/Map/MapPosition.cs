using UnityEngine;

public class MapPosition : MonoBehaviour {
    // 한 칸의 pos 단위 = 2

    //public static Vector3Int PosToMapCoord(Vector3 position) {
    //    // Y축은 사용하지 않으므로 0으로 고정. X, Z 좌표를 정수값으로 변환하여 연산 후 return
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

    // 모든 오브젝트 배치 시 2의 배수로 설정 필요
}
