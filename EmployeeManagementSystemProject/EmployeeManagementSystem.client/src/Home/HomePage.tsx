import { Box, Card, Stack } from '@mui/material';
import meshBackground from '../assets/LavaLamp_bg.png'

const HomePage = () => {




   return (
      <Box sx={{ height: '100vh', width: '100%', display: 'flex', alignItems: 'center', justifyContent: 'center' }}>
         <Stack
            direction="row"
            spacing={15}
            sx={{ height: '100%', flexWrap: 'wrap', width: '100%', alignItems: 'center', justifyContent: 'center' }}>

            <Card
               elevation={10}
               sx={{
                  height: '40vh',
                  width: '30%',
                  backgroundImage: `url(${meshBackground})`,
                  backgroundSize: 'cover',
                  backgroundRepeat: 'no-repeat',
                  backgroundPosition: 'center',
                  borderRadius: '20px',
                  overflow: 'hidden'
               }} />
            <Stack
               direction='row'
               spacing={5}
               sx={{ height: '100%', width: '50%', alignItems: 'center', justifyContent: 'center', overflowX: 'auto' }}>
               <Card
                  elevation={10}
                  sx={{
                     height: '30vh',
                     minWidth: '50%',
                     backgroundImage: `url(${meshBackground})`,
                     backgroundSize: 'cover',
                     backgroundRepeat: 'no-repeat',
                     backgroundPosition: 'center',
                     borderRadius: '20px',
                     overflow: 'hidden'
                  }}
               />
               <Card
                  elevation={10}
                  sx={{
                     height: '30vh',
                     minWidth: '50%',
                     backgroundImage: `url(${meshBackground})`,
                     backgroundSize: 'cover',
                     backgroundRepeat: 'no-repeat',
                     backgroundPosition: 'center',
                     borderRadius: '20px',
                     overflow: 'hidden'
                  }}/>
               <Card
                  elevation={10}
                  sx={{
                     height: '30vh',
                     minWidth: '50%',
                     backgroundImage: `url(${meshBackground})`,
                     backgroundSize: 'cover',
                     backgroundRepeat: 'no-repeat',
                     backgroundPosition: 'center',
                     borderRadius: '20px',
                     overflow: 'hidden'
                  }}/>
            </Stack>
         </Stack>
      </Box>
   )

}

export default HomePage;