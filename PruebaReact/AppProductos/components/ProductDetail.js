// components/ProductDetail.js
import React from 'react';
import { View, Text, Button, StyleSheet } from 'react-native';

const ProductDetail = ({ route, navigation }) => {
    const { product } = route.params;

    return (
        <View style={styles.container}>
            <Text style={styles.title}>{product.nombre}</Text>
            <Text>Precio: {product.precio}</Text>
            <Text>Stock: {product.stock}</Text>
            <Text>Fecha de Ingreso: {product.fechaIngreso}</Text>
            <Text>Producto: {product.producto}</Text>
             
            
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
});

export default ProductDetail;
