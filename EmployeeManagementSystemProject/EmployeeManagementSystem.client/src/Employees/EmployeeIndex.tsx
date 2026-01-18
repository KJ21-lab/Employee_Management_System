import { useGetEmployeesQuery } from './routes';
import { DataGrid, type GridColDef } from '@mui/x-data-grid';
import { type Employee } from './types'
import Box from '@mui/material/Box';
import './EmployeeIndex.scss'
import { AppBar, Toolbar } from '@mui/material';

const columns: GridColDef<Employee>[] = [
   {
      field: 'employeeID',
      headerName: 'Employee ID',
      width: 300,
      editable: true,
      resizable: false
   },
   {
      field: 'name',
      headerName: 'Name',
      type: 'string',
      width: 150,
      editable: true,
      resizable: false
   },
   {
      field: 'jobTitle',
      headerName: 'Job Title',
      type: 'string',
      width: 400,
      resizable: false,
      align: 'left',
      headerAlign: 'left'
   },
   {
      field: 'hireDate',
      headerName: 'Hire Date',
      type: 'string',
      width: 400,
      resizable: false,
      align: 'left',
      headerAlign: 'left',
   },
];

export const EmployeeIndex = () => {

   const { data: habits } = useGetEmployeesQuery();

   console.log(habits)

   return (
      <Box sx={{ height: '98%', width: '98%',flexDirection: 'column', ml:'auto', mt:'auto'}}>
        
            <DataGrid
               sx={{borderRadius: '20px', }}
               rows={habits}
               getRowId={(row: Employee) => row.employeeID}
               columns={columns}
               initialState={{
                  pagination: {
                     paginationModel: {
                        pageSize: 30,
                     },
                  },
               }}

            />
         </Box>
   );
}

export default EmployeeIndex; 