import { Box } from '@mui/material';
import meshBackground from '../assets/mesh-86.png'

const HomePage = () => {




   return (
      <div style={{height: '100%', width: "100%"}}>
         <Box
            height='30%'
            width='50%'
            sx={{
               backgroundImage: `url(${meshBackground})`,
               backgroundSize: 'contain',
               backgroundRepeat: 'no-repeat',
               backgroundPosition: 'center'
            }}>




         </Box>

      </div>


   )

}

export default HomePage;