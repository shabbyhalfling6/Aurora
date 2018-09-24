using UnityEngine;
using System.Collections;

public class ScrollDemoManager : MonoBehaviour 
{
	public Vector2 m_ScrollSpeed;
	public Vector2 m_ScrollSpeed2;

	float m_ExplosiveForce = 1.0f;
	float m_ForceRadius = 1.0f;
	
	float m_Red = 0.0f;
	float m_Green = 0.0f;
	float m_Blue = 255.0f;
	bool m_RandomiseColor = true;
	
	VectorGrid m_VectorGrid;
	VectorGrid m_VectorGrid2;
	
	Color m_StartColor = Color.red;
	Color m_TargetColor = Color.blue;
	float m_ColorInterp;
	
	void Start()
	{
		Application.targetFrameRate = 60;
		m_VectorGrid = GameObject.Find("Stars").GetComponent<VectorGrid>();
		m_VectorGrid2 = GameObject.Find("Aurora").GetComponent<VectorGrid>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Color color = new Color(m_Red/255.0f, m_Green/255.0f, m_Blue/255.0f, 1.0f);

		if(Input.GetMouseButton(0))
		{
			Ray screenRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 worldPosition = screenRay.GetPoint(m_VectorGrid.transform.position.z - Camera.main.transform.position.z);
			worldPosition.z = m_VectorGrid.transform.position.z;
			m_VectorGrid.AddGridForce(worldPosition, m_ExplosiveForce * 0.1f, m_ForceRadius, color, true);

			Vector3 worldPosition2 = screenRay.GetPoint(m_VectorGrid2.transform.position.z - Camera.main.transform.position.z);
			worldPosition2.z = m_VectorGrid2.transform.position.z;
			m_VectorGrid2.AddGridForce(worldPosition2, m_ExplosiveForce * 0.1f, m_ForceRadius, color, true);

		}
		
		if(m_RandomiseColor)
		{
			UpdateRandomColor();
		}

		m_VectorGrid.Scroll(m_ScrollSpeed * Time.deltaTime);
		m_VectorGrid2.Scroll(m_ScrollSpeed2 * Time.deltaTime);
	}
	
	void UpdateRandomColor()
	{
		m_ColorInterp += Time.deltaTime;
		
		if(m_ColorInterp > 1.0f)
		{
			m_ColorInterp -= 1.0f;
			m_StartColor = m_TargetColor;
			m_TargetColor = new Color(UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f));
		}
		
		Color interpolatedColor = m_StartColor + ((m_TargetColor - m_StartColor) * m_ColorInterp);
		m_Red = interpolatedColor.r * 255.0f;
		m_Green = interpolatedColor.g * 255.0f;
		m_Blue = interpolatedColor.b * 255.0f;

		m_VectorGrid.m_ThickLineSpawnColor = interpolatedColor;
		m_VectorGrid2.m_ThickLineSpawnColor = interpolatedColor;
	}
}
