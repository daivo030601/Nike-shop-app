import React, { useRef, useState, useEffect } from "react";
import {
  Image,
  Text,
  View,
  StyleSheet,
  TouchableOpacity,
  Dimensions,
  KeyboardAvoidingView,
} from "react-native";
import Constants from "expo-constants";
import { FlatList, ScrollView, TextInput } from "react-native-gesture-handler";
import StickyParallaxHeader from "react-native-sticky-parallax-header";
import * as firebase from "firebase";
import { Modalize } from "react-native-modalize";
import BackButton from "../component/BackButton";
import { add } from "react-native-reanimated";
import { connect } from "react-redux";
import { addAddress } from "../redux/index.js";

const { width, height } = Dimensions.get("window");

const AddressEdit = ({ navigation,route, ...props }) => {
  const [address, setAddress] = useState({
    name: "",
    city: "",
    district:  "",
    address: "",
    phone:  "",
    pin: "",
  });

  useEffect(() => {
    if(route.params !== undefined)
      setAddress(route.params)
  },[])
  
  const handleChangeAddress = (key, value) => {
    setAddress({
      ...address,
      [key]: value,
    });
  };

  const addAddress = async (address) => {
    try {
      const user = await firebase.auth().currentUser;
      let uid = user.uid;
      //console.log("adding", {...address, "userId": uid})
      await fetch(`${api}/api/Address/Address`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          ...address,
          "userId": uid
        })
      });
    } catch (error) {
      console.error(error);
    }
  }

  const updateAddress = async (address) => {
    try {
      await fetch(`${api}/api/Address/Address`, {
        method: 'PUT',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          ...address,
        })
      });
    } catch (error) {
      console.error(error);
    }
  }

  const handleSubmit = () => {
    if (route.params !== undefined) {
      updateAddress(address)
    } else {
      addAddress(address)
    }
    navigation.goBack();
  };

  return (
    <View style={[StyleSheet.absoluteFill, styles.home]}>
      <View style={{ paddingBottom: 50 }}>
        <ScrollView>
          <View style={styles.navbar}>
            <BackButton />
          </View>
          <Text style={styles.pageTitle}>Edit Address</Text>
          <View style={styles.input}>
            <Text style={styles.inputLabel}>Name</Text>
            <TextInput
              style={styles.inputField}
              placeholder="Elena"
              value={address.name}
              onChangeText={(value) => handleChangeAddress("name", value)}
            />
          </View>
          <View style={styles.input}>
            <Text style={styles.inputLabel}>Phone</Text>
            <TextInput
              style={styles.inputField}
              placeholder="092991XXXX"
              value={address.phone}
              onChangeText={(value) => handleChangeAddress("phone", value)}
            />
          </View>
          <View style={styles.gap}></View>

          <View style={styles.input}>
            <Text style={styles.inputLabel}>Pin code</Text>
            <TextInput
              style={styles.inputField}
              placeholder="722209"
              value={address.pin}
              onChangeText={(value) => handleChangeAddress("pin", value)}
            />
          </View>
          <View style={styles.input}>
            <Text style={styles.inputLabel}>Address</Text>
            <TextInput
              style={styles.inputField}
              placeholder="So 29 Hoang Hoa Tham, Gia Ray..."
              value={address.address}
              onChangeText={(value) => handleChangeAddress("address", value)}
            />
          </View>
          <View style={styles.input}>
            <Text style={styles.inputLabel}>Town/City</Text>
            <TextInput
              style={styles.inputField}
              placeholder="Ha Dong"
              value={address.district}
              onChangeText={(value) => handleChangeAddress("district", value)}
            />
          </View>
          <View style={styles.input}>
            <Text style={styles.inputLabel}>State</Text>
            <TextInput
              style={styles.inputField}
              placeholder="Ha Noi"
              value={address.city}
              onChangeText={(value) => handleChangeAddress("city", value)}
            />
          </View>
        </ScrollView>
      </View>
      <TouchableOpacity style={styles.addBtn} onPress={handleSubmit}>
        <Text style={styles.addBtnText}>Save</Text>
      </TouchableOpacity>
    </View>
  );
};

const mapDispatchToProps = {
  addAddress,
};

export default connect(null, mapDispatchToProps)(AddressEdit);

const styles = StyleSheet.create({
  home: {
    backgroundColor: "#F5F5F5",
  },
  navbar: {
    padding: 10,
    justifyContent: "space-between",
    flexDirection: "row",
    alignItems: "center",
  },
  navbarButton: {
    display: "flex",
    padding: 0,
    width: 30,
    height: 30,
    justifyContent: "center",
    alignItems: "center",
  },
  navbarButtonMargin: {
    marginHorizontal: 0,
  },
  navbarGroup: {
    flexDirection: "row",
    alignItems: "center",
  },
  pageTitle: {
    fontSize: 24,
    fontWeight: "bold",
    color: "#282C40",
    paddingHorizontal: 10,
  },
  addBtn: {
    position: "absolute",
    zIndex: 100,
    bottom: 0,
    backgroundColor: "#5780D9",
    left: 0,
    width: "100%",
    justifyContent: "center",
    flexDirection: "row",
    padding: 15,
  },
  addBtnText: {
    fontWeight: "bold",
    fontSize: 20,
    color: "#fff",
    textTransform: "uppercase",
  },
  input: {
    marginHorizontal: 20,
    marginVertical: 10,
  },
  inputLabel: {
    color: "#C6C6C6",
    fontSize: 14,
  },
  inputField: {
    paddingVertical: 10,
    borderBottomColor: "#7070704D",
    borderBottomWidth: 1,
    fontSize: 14,
    fontWeight: "bold",
    color: "#696C79",
  },
  gap: {
    backgroundColor: "#CBCBCB33",
    height: 10,
    marginVertical: 20,
  },
});
