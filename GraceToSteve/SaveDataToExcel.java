import org.apache.poi.hssf.usermodel.HSSFSheet;
import org.apache.poi.hssf.usermodel.HSSFWorkbook;

public class SaveDataToExcel {
public static void main (String [] args) {
	HSSFWorkbook workbook = new HSSFWorkbook();
	HSSFSheet ticket1 = workbook.createSheet("Ticket 1");
	//Create a new row and cell in current sheet
	Row row = ticket1.createRow(0);
	
	//create cell and set device 
	Cell cell = row.createCell(0);
	cell.setCellValue(device);
	
	Cell cell1 = row.createCell(1);
	cell1.setCellValue(status);

	Map<String, Object[]> ticket = new HashMap<String, Object[]>();
	ticket.put("1", new Object[] {"Emp No.", "Name", "Salary"});
	ticket.put("2", new Object[] {1d, "John", 1500000d});
	ticket.put("3", new Object[] {2d, "Sam", 800000d});
	ticket.put("4", new Object[] {3d, "Dean", 700000d});

	Set<String> keyset = ticket.keySet();
	int rownum = 0;
	for (String key : keyset) {
		Row row = sheet.createRow(rownum++);
		Object [] objArr = ticket.get(key);
		int cellnum = 0;
		for (Object obj : objArr) {
			Cell cell = row.createCell(cellnum++);
			if(obj instanceof Date) 
				cell.setCellValue((Date)obj);
			else if(obj instanceof Boolean)
				cell.setCellValue((Boolean)obj);
			else if(obj instanceof String)
				cell.setCellValue((String)obj);
			else if(obj instanceof Double)
				cell.setCellValue((Double)obj);
		}
	}

	try {
		FileOutputStream out = 
				new FileOutputStream(new File("C:\\new.xls"));
		workbook.write(out);
		out.close();
		System.out.println("Excel written successfully..");

	} catch (FileNotFoundException e) {
		e.printStackTrace();
	} catch (IOException e) {
		e.printStackTrace();
	}	

}	//main
}