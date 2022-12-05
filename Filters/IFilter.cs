namespace MyPhotoshop
{
	public interface IFilter
	{
        /// <summary>
        /// ���� ����� ������ ���������� �������� ����������, ������� ���������� � NumericUpDown-��������
        /// ����� �� �������� ������ �������
        /// </summary>
        /// <returns></returns>
  	    ParameterInfo[] GetParameters();
        /// <summary>
        /// ���� ����� ��������� ����������, ������� ���� ������������, � ��������� �������� ���� ����������
        /// ����� ������� values � �������� ����� ����� �������, ������������� ������� GetDescription
        /// </summary>
        /// <param name="original"></param>
        /// <param name="values"></param>
        /// <returns></returns>
		Photo Process(Photo original, double[] values);
	}
}

