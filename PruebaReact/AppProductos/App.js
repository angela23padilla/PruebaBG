import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import { Button } from 'react-native'; // Asegúrate de importar Button
import ProductList from './components/ProductList';
import ProductDetail from './components/ProductDetail';
import Cart from './components/Cart';
import LoginScreen from './components/Login';
import Toast from 'react-native-toast-message';

const Stack = createStackNavigator();

const App = () => {
  return (
    <NavigationContainer>
      <Stack.Navigator initialRouteName="Login">
        <Stack.Screen 
          name="Login" 
          component={LoginScreen} 
          options={{ title: 'Iniciar Sesión' }} 
        />
        <Stack.Screen 
          name="ProductDetail" 
          component={ProductDetail} 
          options={{ title: 'Detalle del Producto' }} 
        />
        <Stack.Screen 
          name="ProductList" 
          component={ProductList} 
          options={({ navigation }) => ({
            title: 'Lista de Productos',
            headerRight: () => (
              <Button
                onPress={() => navigation.navigate('Cart')}
                title="Carrito"
                color="#000"
              />
            ),
          })}
        />
        <Stack.Screen 
          name="Cart" 
          component={Cart} 
          options={{ title: 'Carrito' }} 
        />
      </Stack.Navigator>
      <Toast ref={(ref) => Toast.setRef(ref)} /> {/* Agrega Toast aquí */}
    </NavigationContainer>
  );
};

export default App;
