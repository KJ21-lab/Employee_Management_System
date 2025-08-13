import { useState } from 'react'; // No longer need useEffect for data fetching
import { useGetHabitsQuery } from './routes'; // Import RTK Query hooks
import { Button } from '@mui/material';
import { DataGrid, type GridColDef } from '@mui/x-data-grid';
import { type Habit } from './types'
import Box from '@mui/material/Box';
import './App.css'

const columns: GridColDef<(Habit[])[number]>[] = [
  {
    field: 'habitId',
    headerName: 'Habit id',
    width: 150,
    editable: true,
    resizable: false
  },
  {
    field: 'habitName',
    headerName: 'Habit Name',
    width: 150,
    editable: true,
    resizable: false
  },
  {
    field: 'habitDesc',
    headerName: 'Habit Description',
    type: 'number',
    width: 400,
    resizable: false,
    align: 'left',
    headerAlign: 'left'
  },
];

function App() {

  const { data: habits } = useGetHabitsQuery();


  // States for the new habit form inputs remain
  const [newHabit, setNewHabit] = useState('');

  console.log(habits)

  return (
    <div className="data-grid">
    <Box sx={{ height: 600, width: 900}}>
      <DataGrid
      
      rows={habits}
      getRowId={(row: Habit) => row.habitId}
      columns={columns}
      
      initialState={{
          
          pagination: {
            paginationModel: {
              pageSize: 20,
            },
          },
        }}
      
      />

      <Button variant="contained">
        Contained
      </Button>
      <span>BOB</span>
   </Box>
   </div>
  );
}

export default App; // Exports the App component for use in other files.