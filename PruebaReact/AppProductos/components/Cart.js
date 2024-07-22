// components/Cart.js
import React, { useEffect, useState } from 'react';
import { View, Text, FlatList, Button, StyleSheet } from 'react-native';
import { getCartItems } from '../services/productService';

const Cart = ({ navigation }) => {
    const [cartItems, setCartItems] = useState([]);

    useEffect(() => {
        fetchCartItems();
    }, []);

    const fetchCartItems = async () => {
        try {
            const response = await getCartItems();
            setCartItems(response);
        } catch (error) {
            console.error('Error fetching cart items:', error);
        }
    };

    return (
        <View style={styles.container}>
            <Text style={styles.title}>Carrito</Text>
            <FlatList
                data={cartItems}
                keyExtractor={(item, index) => index.toString()}
                renderItem={({ item }) => (
                    <View style={styles.cartItem}>
                        <Text>{item.nombre}</Text>
                        <Text>{item.precio}</Text>
                    </View>
                )}
            />
            <Button title="Volver a Productos" onPress={() => navigation.navigate('ProductList')} />
        </View>
    );
};

const styles = StyleSheet.create({
    container: {
        flex: 1,
        padding: 20,
        backgroundColor: '#fff',
    },
    title: {
        fontSize: 24,
        fontWeight: 'bold',
        marginBottom: 20,
    },
    cartItem: {
        flexDirection: 'row',
        justifyContent: 'space-between',
        padding: 10,
        borderBottomWidth: 1,
        borderBottomColor: '#ccc',
    },
});

export default Cart;
