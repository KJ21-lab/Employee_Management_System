import { useGetHabitsQuery } from './routes';
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

    console.log(habits)

    return (
        <div className="data-grid">
            <Box sx={{ height: 600, width: 900 }}>
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

export default App; 