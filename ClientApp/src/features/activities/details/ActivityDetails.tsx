import { Grid } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import { useParams } from "react-router-dom";
import LoadingComponent from "../../../app/layout/LoadingComponent";
import ActivityDetailsHeader from "./ActivityDetailsHeader";
import ActivityDetailsInfo from "./ActivityDetailsInfo";
import ActivityDetailsChat from "./ActivityDetailsChat";
import ActivityDetailsSidebar from "./ActivityDetailsSidebar";

export default observer(function ActivityDetails() {

    const { activityStore } = useStore();
    const { selectedActivity: activity, loadActivity, loadingInitial } = activityStore;
    const { id } = useParams();

    useEffect(() => {
        if (id)
            loadActivity(id);
    }, [id, loadActivity])

    if (loadingInitial || !activity) return <LoadingComponent content={""} />;

    return (
        <Grid>
            <Grid.Column width={10}>
                <ActivityDetailsHeader activity={activity} />
                <ActivityDetailsInfo activity={activity} />
                <ActivityDetailsChat />
            </Grid.Column>
            <Grid.Column width={6}>
                <ActivityDetailsSidebar />
            </Grid.Column>
        </Grid>
    )
})
