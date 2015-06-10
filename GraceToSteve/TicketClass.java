import org.apache.poi.hssf.usermodel.HSSFSheet;
import org.apache.poi.hssf.usermodel.HSSFWorkbook;

public class SaveDataToExcel {
	
	HSSFWorkbook workbook = new HSSFWorkbook();
	HSSFSheet ticket1 = workbook.createSheet("Ticket 1");
	//Create a new row and cell in current sheet
	Row row = sheet.createRow(0);
	
	//create cell and set device 
	Cell cell = row.createCell(0);
	cell.setCellValue(device);
	
	Cell cell1 = row.createCell(1);
	cell1.setCellValue(status);