import { useGetEmployeesQuery } from './routes';
//import { DataGrid, GridRowModes, ToolbarButton, type GridColDef, type GridRowModesModel, type GridRowsProp, type GridSlotProps, type GridSlots } from '@mui/x-data-grid';
import DataGrid, { Column, Editing, FilterRow } from 'devextreme-react/data-grid';
import Box from '@mui/material/Box';
import './EmployeeIndex.scss'

export const EmployeeIndex = () => {

   const { data: employees } = useGetEmployeesQuery();

   console.log(employees)

   return (
      <Box height="100vh" width="85vw" justifyContent="flex-end" alignItems="center"border="8px solid black" alignSelf="flex-end">
         <DataGrid
            dataSource={employees}
            keyExpr="employeeID"
            width="100%"
            showBorders
            rowAlternationEnabled>

            <Column
               dataField="employeeID"
               caption="Employee ID"
               alignment="left"
            />
            <Column
               dataField="name"
               caption="Name"
               alignment="left"
            />
            <Column
               dataField="jobTitle"
               caption="Job Title"
               alignment="left"
            />
            <Column
               dataField="hireDate"
               caption="Hire Date"
               alignment="left"
               dataType="date"
            />
            <FilterRow visible={true} />
            <Editing
               mode="row"
               allowUpdating
               allowDeleting
               allowAdding />
         </DataGrid>

      </Box>
   );
}

export default EmployeeIndex; 